﻿using Tp3.Models;

namespace Tp3.Services.ServiceContracts
{
    public interface IMovieService
    {
        public List<Movie> GetMoviesByGenre(string genreName);

        public List<Movie> GetMoviesByGenreID(int genreId);

        public List<Movie> GetMoviesSortedByReleaseDateDescending();

    }
}
