namespace Sarah_portugues;

public partial class pergunta1 : ContentPage
{
    private bool respondida = false;
    public pergunta1()
    {
        InitializeComponent();
        lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
    }

    private async void OnResponderClicked(object sender, EventArgs e)
    {
        if (respondida)
        {
            await Navigation.PushAsync(new pergunta2());
            return;
        }

        if (!(rbA.IsChecked || rbB.IsChecked || rbC.IsChecked || rbD.IsChecked))
        {
            lblResultado.Text = "Selecione uma alternativa.";
            return;
        }

        rbA.IsEnabled = false;
        rbB.IsEnabled = false;
        rbC.IsEnabled = false;
        rbD.IsEnabled = false;

        rbB.TextColor = Colors.Green;
        rbB.BackgroundColor = Color.FromArgb("#B3C8E6C9");

        if (rbB.IsChecked)
        {
            ScoreStore.Add(10);
            lblResultado.Text = "Resposta correta!";
            lblResultado.TextColor = Colors.Green;
            lblPontuacao.Text = $"Pontuação: {ScoreStore.Points}";
        }
        else if (rbA.IsChecked || rbC.IsChecked || rbD.IsChecked)
        {
           
            RadioButton marcada = rbA.IsChecked ? rbA :
                                  rbC.IsChecked ? rbC : rbD;

            marcada.TextColor = Colors.Red;
            marcada.BackgroundColor = Color.FromArgb("#B3FFCDD2");

            lblResultado.Text = "Resposta incorreta \nA resposta certa é a letra B";
            lblResultado.TextColor = Colors.Red;
            lblPontuacao.Text = $"Pontuação: {ScoreStore.Points}";
        }

        respondida = true;
        btnResponder.Text = "Próxima pergunta";
    }
}