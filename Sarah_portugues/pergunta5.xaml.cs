namespace Sarah_portugues;

public partial class pergunta5 : ContentPage
{
    private bool respondida = false;
    public pergunta5()
	{
		InitializeComponent();
        lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
    }

    private async void OnResponderClicked(object sender, EventArgs e)
    {
        if (respondida)
        {
            await Navigation.PushAsync(new pergunta6());
            return;
        }

        if (!(rbA.IsChecked || rbB.IsChecked || rbC.IsChecked || rbD.IsChecked))
        {
            lblResultado.Text = "Selecione uma alternativa.";
            return;
        }

        rbA.InputTransparent = true;
        rbB.InputTransparent = true;
        rbC.InputTransparent = true;
        rbD.InputTransparent = true;

        bdB.BackgroundColor = Color.FromArgb("#E6A5D6A7");

        if (rbB.IsChecked)
        {
            ScoreStore.Add(10);
            lblResultado.Text = "Resposta correta!";
            lblResultado.TextColor = Colors.Green;
            lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
        }
        else if (rbA.IsChecked || rbC.IsChecked || rbD.IsChecked)
        {
            if (rbA.IsChecked) bdA.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbC.IsChecked) bdC.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbD.IsChecked) bdD.BackgroundColor = Color.FromArgb("#E6EF9A9A");

            lblResultado.Text = "Resposta incorreta.\nA resposta certa é a letra B.";
            lblResultado.TextColor = Colors.Red;
            lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
        }

        respondida = true;
        btnResponder.Text = "Próxima pergunta";
    }
}