﻿using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using ContosoUniversity.DAL;
using ContosoUniversity.DomainManagers;
using ContosoUniversity.Models;
using Microsoft.Azure.Mobile.Server;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : TableController<DepartmentDTO>
    {
        private SchoolContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new SchoolContext();
            this.DomainManager = new DepartmentMappedDomainManager(context, controllerContext.Request, false);
        }

        public SingleResult<DepartmentDTO> Get(string id)
        {
            return Lookup(id);
        }

        public IQueryable<DepartmentDTO> GetAllStudents()
        {
            return Query();
        }
    }
}