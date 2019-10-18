using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bitspco.Framework.Common;
using Bitspco.Framework.Common.Query;
using Bitspco.Framework.Filters;
using Bitspco.Framework.Filters.ErrorHandler;
using Bitspco.Framework.Filters.Log;
using Bitspco.Framework.Filters.Security;
using Bitspco.Framework.Filters.Security.AntiDos;
using Bitspco.Framework.Filters.Security.Authenticate;
using Bitspco.Framework.Filters.Security.IP;
using Bitspco.Framework.Filters.Security.Models;
using Bitspco.Framework.Filters.Validator;
using Bitspco.Framework.Net.Filters.Security;
using Bitspco.Framework.Net.Logger.Contexts;
using ERP.PMS.Business;
using ERP.PMS.Common.Intefaces;
using ERP.PMS.Data;
using ERP.PMS.Data.Contexts;
using ERP.PMS.Facade.Filters;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        const string CONNECTION_STRING = "";

        private IDataAdapter adapter;
        private PMSBusiness business;

        private Authenticator auth;
        private readonly AuthFilter authFilter = new AuthFilter();
        private readonly LogFilter logFilter = new LogFilter(new Logger());
        private readonly SecurityFilter securityFilter = new SecurityFilter();
        private readonly AntiDosFilter antiDosFilter = new AntiDosFilter();
        private readonly ErrorHandlerFilter errorHandlerFilter = new ErrorHandlerFilter();
        private readonly ValidatorFilter validatorFilter = new ValidatorFilter();
        private readonly IPFilter ipFilter = new IPFilter();
        private readonly FilterCollection<IFilter> filters = new FilterCollection<IFilter>();

        private PMSBusiness Business
        {
            get
            {
                if (business == null)
                {
                    business = new PMSBusiness(Adapter);
                }
                return business;
            }
        }
        private IDataAdapter Adapter
        {
            get
            {
                if (adapter != null) return adapter;
                var PMSContext = new PMSDbContext(CONNECTION_STRING);
                var loggerDbContext = new LoggerDbContext(CONNECTION_STRING);
                return adapter = new DataAdapter(PMSContext);
            }
        }
        static PMSController()
        {
            Mappers.AutoMapperConfig.Configure();
        }
        public PMSController()
        {
            filters.Add(logFilter);

            antiDosFilter.AttributeEnable = true;
            securityFilter.Filters.Add(authFilter);
            securityFilter.Filters.Add(antiDosFilter);
            securityFilter.Filters.Add(ipFilter);

            filters.Add(securityFilter);

            filters.Add(validatorFilter);
            filters.Add(errorHandlerFilter);
        }
        public void RegisterSecurity(HttpRequest request)
        {
            securityFilter.ClientInfo = new ClientInfo().GetClientInfo(request, "");
        }
        public void RegisterAuthenticator(string token)
        {
            auth = new Authenticator() { Token = token };
            authFilter.SetAuthenticator(auth);
        }

        private Promise<T> Run<T>(Func<T> func, bool saveChanges = false, object[] arguments = null)
        {
            T result = default(T);
            filters.BeginExecute(frameBack: 2, arguments: arguments);
            try { result = func(); if (saveChanges) Adapter.SaveChanges(); }
            catch (Exception e) { errorHandlerFilter.SetException(e); }
            finally { filters.EndExecute(); }
            return new Promise<T>(result);
        }
        //------------------------------ CRUD ------------------------------
        #region CRUD
        public int Count<T>() where T : class => Run(() => Adapter.Count<T>()).Result;
        public List<R> Select<T, R>(QueryOptions options) where T : class => Run(() => options.ApplyTo(Adapter.Select<T>()).ToList()).Then(Mapper.Map<List<R>>).Result;
        public List<R> GetAll<T, R>() where T : class => Run(() => Adapter.Select<T>().ToList()).Then(Mapper.Map<List<R>>).Result;
        public R GetById<T, R>(object id) where T : class => Run(() => Adapter.GetById<T>(id)).Then(Mapper.Map<R>).Result;
        public R Add<T, R, Q>(Q obj) where T : class => Run(() => Adapter.Insert(Mapper.Map<T>(obj)), saveChanges: true).Then(Mapper.Map<R>).Result;
        public R Change<T, R, Q>(object id, Q obj) where T : class => Run(() => Adapter.Update(Mapper.Map(obj, Adapter.GetById<T>(id))), saveChanges: true).Then(Mapper.Map<R>).Result;
        public R Remove<T, R>(object id) where T : class => Run(() => Adapter.Delete(Adapter.GetById<T>(id)), saveChanges: true).Then(Mapper.Map<R>).Result;
        #endregion

        //        [Auth("p:GetAllWorkExperience"), Log]
        //        public List<WorkExperienceGetDto> GetAllWorkExperience()
        //        {
        //            return Mapper.Map<WorkExperienceGetDto>(GetAll<WorkExperience>());
        //        }
    }
}