namespace Sarah_portugues;

public partial class pergunta4 : ContentPage
{
    private bool respondida = false;
    public pergunta4()
	{
		InitializeComponent();
        lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
    }

    private async void OnResponderClicked(object sender, EventArgs e)
    {
        if (respondida)
        {
            await Navigation.PushAsync(new pergunta5());
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

        // Destaca a alternativa correta em verde
        bdD.BackgroundColor = Color.FromArgb("#E6A5D6A7");

        if (rbD.IsChecked)
        {
            //Adiciona pontos ao score
            ScoreStore.Add(10);
            lblResultado.Text = "Resposta correta!";
            lblResultado.TextColor = Colors.Green;
            lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
        }
        else if (rbA.IsChecked || rbB.IsChecked || rbC.IsChecked)
        {
            //Nenhum ponto adicionado para respostas incorretas
            if (rbA.IsChecked) bdA.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbB.IsChecked) bdB.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbC.IsChecked) bdC.BackgroundColor = Color.FromArgb("#E6EF9A9A");

            lblResultado.Text = "Resposta incorreta.\nA resposta certa é a letra D.";
            lblResultado.TextColor = Colors.Red;
            lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
        }

        respondida = true;
        btnResponder.Text = "Próxima pergunta";
    
}
}