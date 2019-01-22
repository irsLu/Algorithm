

using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.InteropServices;

public class DisposeSample : IDisposable
{
    // 非托管 从系统非托管堆上分配100字节，IntPtr 开始地址
    private IntPtr nativeResource = Marshal.AllocHGlobal(100);

    // 托管
    private List<int> managedResource;

    private bool disposed = false;

    // 实现接口
    public void Dispose()
    {
        Dispose(true);

        // 通知gc不在调用析构器
        GC.SuppressFinalize(this);
    }

    // 提供一个Close方法是为更符合其他语言规范
    public void Close()
    {
        Dispose();
    }

    // 析构
    ~DisposeSample()
    {
        Dispose(false);
    }

    public void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            // 释放托管资源
            if (managedResource != null)
            {
                managedResource.Clear();
                managedResource = null;
            }
        }

        // 释放非托管资源
        if (nativeResource != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(nativeResource);
            nativeResource = IntPtr.Zero;
        }

        disposed = true;
    }

}
