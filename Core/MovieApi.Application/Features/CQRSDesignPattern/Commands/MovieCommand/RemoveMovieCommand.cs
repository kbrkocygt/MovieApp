using System;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommand;

public class RemoveMovieCommand
{
    public int MovieId { get; set; }

}
