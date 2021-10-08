using System;

namespace CrossCutting
{
    public class Erro
    {
        public Erro()
        {
            Numero = Tipo.SemErro;
        }

        public Erro(Tipo numero,string mensagem)
        {
            Numero = numero;
            Mensagem = mensagem;
        }

        public Erro(Tipo numero, Exception mensagem)
        {
            Numero = numero;
            _Mensagem = mensagem;
        }

        public Tipo Numero { get; set; }
        public string Mensagem { get; set; }
        public Exception _Mensagem { get; set; }

        public enum Tipo
        {
            SemErro = 0,
            Indefinido = 1
        }
    }
}