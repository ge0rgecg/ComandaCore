namespace Dominio
{
    public class Retorno<T>
    {
        public bool Ok { get; set; }

        public string Mensagem { get; set; }

        public T Objeto { get; set; }
    }
}
