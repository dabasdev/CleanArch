using System.Windows;
using CleanArch.Application.Features.Posts.Queries.GetPostsList;
using MediatR;

namespace WpfApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IMediator _mediator;

    public MainWindow(IMediator mediator)
    {
        InitializeComponent();
        _mediator = mediator;
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        var dto = await _mediator.Send(new GetPostsListQuery());

        if (dto.Count > 0) Dgv.ItemsSource = dto;
    }
}