using Autofac;

namespace HelpConfig
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Carrega IOC

            HelpIOC.Load(builder);

            #endregion
        }
    }
}
