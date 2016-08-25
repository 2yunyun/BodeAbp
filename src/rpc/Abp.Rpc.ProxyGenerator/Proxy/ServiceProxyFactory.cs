﻿using System;
using System.Linq;
using System.Reflection;
using Abp.Rpc.Client;

namespace Abp.Rpc.ProxyGenerator.Proxy
{
    /// <summary>
    /// 默认的服务代理工厂实现。
    /// </summary>
    public class ServiceProxyFactory : IServiceProxyFactory
    {
        #region Field

        private readonly IRemoteInvokeService _remoteInvokeService;

        #endregion Field

        #region Constructor

        public ServiceProxyFactory(IRemoteInvokeService remoteInvokeService)
        {
            _remoteInvokeService = remoteInvokeService;
        }

        #endregion Constructor

        #region Implementation of IServiceProxyFactory

        /// <summary>
        /// 创建服务代理。
        /// </summary>
        /// <param name="proxyType">代理类型。</param>
        /// <returns>服务代理实例。</returns>
        public object CreateProxy(Type proxyType)
        {
            var instance = proxyType.GetTypeInfo().GetConstructors().First().Invoke(new object[] { _remoteInvokeService });
            return instance;
        }

        #endregion Implementation of IServiceProxyFactory
    }
}
