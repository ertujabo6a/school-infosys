using ICS.BL.Facades.Interfaces;
using ICS.BL.Mappers;
using ICS.BL.Mappers.Interfaces;
using ICS.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ICS.BL;

public static class BLInstaller
{
    public static IServiceCollection AddBLServices(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();

        services.Scan(selector => selector
            .FromAssemblyOf<BusinessLogic>()
            .AddClasses(filter => filter.AssignableTo(typeof(IFacade<,,>)))
            .AsMatchingInterface()
            .WithSingletonLifetime());

        var activityModelMapper = new ActivityModelMapper();
        var evaluationModelMapper = new EvaluationModelMapper();
        var subjectModelMapper = new SubjectModelMapper(null!, activityModelMapper);
        var studentModelMapper = new StudentModelMapper(subjectModelMapper);
        subjectModelMapper.SetStudentModelMapper(studentModelMapper);

        services.AddSingleton(typeof(IActivityModelMapper), activityModelMapper);
        services.AddSingleton(typeof(IEvaluationModelMapper), evaluationModelMapper);
        services.AddSingleton(typeof(ISubjectModelMapper), subjectModelMapper);
        services.AddSingleton(typeof(IStudentModelMapper), studentModelMapper);

        /*services.Scan(selector => selector
            .FromAssemblyOf<BusinessLogic>()
            .AddClasses(filter => filter.AssignableTo(typeof(IModelMapper<,,>)))
            .AsSelfWithInterfaces()
            .WithSingletonLifetime());*/

        return services;
    }
}
