using LightInject;


namespace PruebaIngreso
{
    public static class CodeTestDefaultServices
    {
        public static void Register (IServiceContainer services)
        {
            services.Register<IMarginProvider,DefaultMarginProvider > ();
            services.Decorate<IMarginProvider>((service, factory) => new MarginProvider(factory));
            services.Register<MarginService>();
        }
    }
}