﻿namespace PontoOpen.Domain.Exceptions;

public class UnauthorizedException(string message) : Exception(message)
{
}