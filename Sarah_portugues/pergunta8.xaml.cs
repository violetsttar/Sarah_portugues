namespace Sarah_portugues;

public partial class pergunta8 : ContentPage
{
    private const int TotalPerguntas = 8;
    private const int PontosPorAcerto = 10;
    private bool respondida = false;
    public pergunta8()
	{
		InitializeComponent();
        lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
    }

    private async void OnResponderClicked(object sender, EventArgs e)
    {
        if (respondida)
        {
            ScoreStore.Reset();
            await Navigation.PopToRootAsync(); // volta para a MainPage
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

        bdA.BackgroundColor = Color.FromArgb("#E6A5D6A7");

        if (rbA.IsChecked)
        {
            ScoreStore.Add(10);
            lblResultado.Text = "Resposta correta!";
            lblResultado.TextColor = Colors.Green;
            lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";
        }
        else if (rbB.IsChecked || rbC.IsChecked || rbD.IsChecked)
        {
            if (rbB.IsChecked) bdB.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbC.IsChecked) bdC.BackgroundColor = Color.FromArgb("#E6EF9A9A");
            if (rbD.IsChecked) bdD.BackgroundColor = Color.FromArgb("#E6EF9A9A");

            lblResultado.Text = "Resposta incorreta.\nA resposta certa é a letra A.";
            lblResultado.TextColor = Colors.Red;
        }
        lblPontuacao.Text = $"Pontos: {ScoreStore.Points}";

        int maximo = TotalPerguntas * PontosPorAcerto; // 80
        lblFinal.Text = $"Resultado: {ScoreStore.Points} de {maximo} pontos";
        bdFinal.IsVisible = true;

        respondida = true;
        btnResponder.Text = "Jogar novamente";
    }
}