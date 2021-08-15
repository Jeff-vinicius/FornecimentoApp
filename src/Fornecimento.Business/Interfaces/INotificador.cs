using System;
using System.Collections.Generic;
using System.Text;
using Fornecimento.Business.Notifications;

namespace Fornecimento.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> GetNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
