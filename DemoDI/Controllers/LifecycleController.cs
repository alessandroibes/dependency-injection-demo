using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoDI.Controllers
{
    public class LifecycleController : Controller
    {
        public OperacaoService OperacaoService { get; }
        public OperacaoService OperacaoService2 { get; }

        public LifecycleController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
        }

        public string Index()
        {
            return
                "Primeira instância: " + Environment.NewLine +
                "Transient:         " + OperacaoService.Transient.OperacaoId + Environment.NewLine +
                "Scoped:            " + OperacaoService.Scoped.OperacaoId + Environment.NewLine +
                "Singleton:         " + OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                "SingletonInstance: " + OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Segunda instância: " + Environment.NewLine +
                "Transient:         " + OperacaoService2.Transient.OperacaoId + Environment.NewLine +
                "Scoped:            " + OperacaoService2.Scoped.OperacaoId + Environment.NewLine +
                "Singleton:         " + OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
                "SingletonInstance: " + OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        }
    }
}
