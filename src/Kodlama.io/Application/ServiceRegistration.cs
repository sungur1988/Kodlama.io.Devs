using Application.Features.Auth.Rules;
using Application.Features.LanguageTechs.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.Users.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(ProgrammingLanguageBusinessRules));
            services.AddScoped(typeof(LanguageTechBusinessRules));
            services.AddScoped(typeof(AuthBusinessRules));
            services.AddScoped(typeof(UserBusinessRules));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
