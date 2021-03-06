﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Domain.Abstract
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
    }
}
