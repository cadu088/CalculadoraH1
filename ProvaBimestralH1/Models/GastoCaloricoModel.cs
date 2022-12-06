namespace ProvaBimestralH1.Models
{
    public class GastoCaloricoModelEntrada
    {
        public GastoCaloricoModelEntrada(string sexo, double quilo, int idade)
        {
            Sexo = sexo;
            Quilo = quilo;
            Idade = idade;
        }

        public string Sexo { get; set; }
        public double Quilo { get; set; }
        public int Idade { get; set; }

    }

    public class GastoCaloricoModelSaida
    {
        public GastoCaloricoModelSaida(double caloriasDiarias)
        {
            CaloriasDiarias = caloriasDiarias;
        }

        public double CaloriasDiarias { get; set; }

    }

    public class GastoCaloricoAtividadelSaida
    {
        public GastoCaloricoAtividadelSaida(double caloriasDiarias)
        {
            CaloriasDiarias = caloriasDiarias;
        }

        public double CaloriasDiarias { get; set; }

    }
}
