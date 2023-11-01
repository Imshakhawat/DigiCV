using Autofac;
using CVBuilder.Worker;
using CVBuilder.Worker.Model;

internal class WorkerModule : Module
{

    private readonly IConfiguration _configuration;
    public WorkerModule()
    {
        
    }
    public WorkerModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<Worker>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<MailSender>().AsSelf().InstancePerLifetimeScope();

    }
}