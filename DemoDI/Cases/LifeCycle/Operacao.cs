﻿using System;

namespace DemoDI.Cases
{
    public class Operacao : IOperacaoTransient,
        IOperacaoScoped,
        IOperacaoSingleton,
        IOperacaoSingletonInstance
    {
        public Operacao() : this(Guid.NewGuid())
        {
        }

        public Operacao(Guid id)
        {
            OperacaoId = id;
        }

        public Guid OperacaoId { get; private set; }
    }
}
