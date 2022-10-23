using Autofac;
using Contact.BusinessLogic.Abstract;
using Contact.BusinessLogic.ContactServices;
using Contact.DataAccess.Abstract;
using Contact.DataAccess.Concrete;
using Module = Autofac.Module;
namespace Contact.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //BLL
            builder.RegisterType<ContactBLL>().As<IContactBLL>().InstancePerLifetimeScope();

            //DAL
            builder.RegisterType<ContactDAL>().As<IContactDAL>().InstancePerLifetimeScope();
        }
    }
}
