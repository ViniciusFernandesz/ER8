using System;

namespace EncontroRemoto
{
    public class PessoaFisica : Pessoa
    {
        public string? cpf { get; set; }
        
        public DateTime dataNascimento { get; set; }

        public override double PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;

            }else if (rendimento > 1500 && rendimento <= 5000)
            {
                return (rendimento/100) *3; //*0,03  (rendimento/100)*3;   *1.03

            }else{
                return (rendimento/100) *5;
            }                      
        }        
        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if (anos >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }    
    }

}