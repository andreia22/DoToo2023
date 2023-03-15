using Autofac;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using DoToo.Views;
using DoToo.ViewModels;
using DoToo.Repositories;


namespace DoToo
{
    public abstract class Bootstrapper
    {

        protected ContainerBuilder ContainerBuilder

        {  get;  private set; }

        protected Bootstrapper()
        {

            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            var assemblyList =
                currentAssembly.DefinedTypes
                .Where( e => e.IsSubclassOf(typeof(Page)) || 
                             e.IsSubclassOf(typeof(ViewModel)) );

            foreach ( var type in assemblyList ) 
            {
                ContainerBuilder.RegisterType(type.AsType());
            }

            ContainerBuilder.RegisterType<TodoItemRepository>()
                .SingleInstance();

            // esta operação sera executada para todo e qualquer classe de objeto que sejá necesssaria a inclusao para consulmo via ingeção de dependencia
                
            
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }

    }
}
