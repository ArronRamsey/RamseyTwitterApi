﻿using Microsoft.Extensions.Logging;

namespace UnitTests
{
    /// <summary>
    /// Testing mock for ILogger<T>
    /// https://github.com/nsubstitute/NSubstitute/issues/597
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MockLogger<T> : ILogger<T>
    {
        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) =>
        Log(logLevel, formatter(state, exception));

        public abstract void Log(LogLevel logLevel, string message);

        public virtual bool IsEnabled(LogLevel logLevel) => true;

        public abstract IDisposable BeginScope<TState>(TState state);

    }
}
