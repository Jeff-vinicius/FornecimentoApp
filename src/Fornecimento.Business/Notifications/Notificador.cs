using Fornecimento.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fornecimento.Business.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notifications;

        public Notificador()
        {
            _notifications = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<Notificacao> GetNotificacoes()
        {
            return _notifications;
        }

        public bool TemNotificacao()
        {
            return _notifications.Any();
        }
    }
}
