namespace patron_singleton
{
    public class Singleton
    {
        private static Singleton instancia = null;
        public string mensaje = "";
        protected Singleton()
        {
            mensaje = "instancia cargada";
        }
        public static Singleton Instancia
        {
            get
            {
                if(instancia == null)
                    instancia = new Singleton();
                return instancia;
            }
        }
    }
}
