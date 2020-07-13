﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Iti.Baseline.Auth;
using Iti.Baseline.Inversion;
using Iti.Baseline.Logging;

namespace Iti.Baseline.Core.Tasks
{
    public static class TaskRunner
    {
        public static Task Run<T>(string name, IAuthScopeResolver authResolver, Action<T> action)
        {
            var task = Task.Run(() =>
            {
                try
                {
                    using (var innerScope = authResolver.BeginLifetimeScope())
                    {
                        var st = innerScope.Resolve<T>();
                        action(st);
                    }
                }
                catch (Exception exc)
                {
                    StaticLog.Log.Error($"TASK ERROR: {typeof(T).Name}:{name}: {exc.Message}", exc);
                }
            });

            return task;
        }

        public static Task<TResult> Run<T, TResult>(string name, IAuthScopeResolver authResolver, Func<T, TResult> action, Func<TResult> defaultValue)
        {
            var task = Task.Run(() =>
            {
                try
                {
                    using (var innerScope = authResolver.BeginLifetimeScope())
                    {
                        var st = innerScope.Resolve<T>();
                        return action(st);
                    }
                }
                catch (Exception exc)
                {
                    StaticLog.Log.Error($"TASK ERROR: {typeof(T).Name}:{name}: {exc.Message}", exc);
                    return defaultValue();
                }
            });

            return task;
        }
    }
}
