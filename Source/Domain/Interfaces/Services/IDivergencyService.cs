﻿using DesafioIntelitrader.Source.Domain.Entites;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    interface IDivergencyService 
    {
        List<string> CalculateDivergency();
    }
}