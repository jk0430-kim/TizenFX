/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System.ComponentModel;

namespace Tizen.NUI
{
    using global::System;

    /// <summary>
    /// NativeImageQueue is a class for displaying an image resource using queue.
    /// </summary>
    /// <example>
    /// <code>
    /// NativeImageQueue queue = new NativeImageQueue(width,height,ColorFormat.RGBA8888);
    /// if(queue.CanDequeueBuffer())
    /// {
    ///   var buffer = queue.DequeueBuffer(ref bufferWidth,ref bufferHeight,ref bufferStride);
    ///
    ///   /* Use buffer */
    ///
    ///   queue.EnqueueBuffer(buffer);
    /// }
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NativeImageQueue : NativeImageInterface
    {
        private IntPtr handle;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ColorFormat
        {
            /// <summary>
            /// 8 blue bits, 8 green bits, 8 red bits
            /// </summary>
            BGR888 = 0,

            /// <summary>
            /// 8 blue bits, 8 green bits, 8 red bits, alpha 8 bits
            /// </summary>
            BGRA8888 = 1,

            /// <summary>
            /// 8 blue bits, 8 green bits, 8 red bits, and 8 ignored bits
            /// </summary>
            BGRX8888 = 2,

            /// <summary>
            /// 8 red bits, 8 green bits, 8 blue bits
            /// </summary>
            [System.ObsoleteAttribute("This property is obsolete. It's behavior could be changed in a future version. Currently it is same as BGR888", false)]
            RGB888 = 0,

            /// <summary>
            /// 8 red bits, 8 green bits, 8 blue bits, alpha 8 bits
            /// </summary>
            [System.ObsoleteAttribute("This property is obsolete. It's behavior could be changed in a future version. Currently it is same as BGRA8888", false)]
            RGBA8888 = 1,

            /// <summary>
            /// 8 red bits, 8 green bits, 8 blue bits, and 8 ignored bits
            /// </summary>
            [System.ObsoleteAttribute("This property is obsolete. It's behavior could be changed in a future version. Currently it is same as BGRX8888", false)]
            RGBX8888 = 2,
        }

        /// <summary>
        /// Creates an initialized NativeImageQueue with size and color format.
        /// </summary>
        /// <param name="width">A Width of queue.</param>
        /// <param name="height">A Height of queue.</param>
        /// <param name="colorFormat">A color format of queue.</param>
        /// <returns>A NativeImageQueue.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NativeImageQueue(uint width, uint height, ColorFormat colorFormat) : this(0, width, height, colorFormat)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an initialized NativeImageQueue with queue count and size and color format.
        /// </summary>
        /// <remarks>Since queueCount can increase the memory usage, we recommened queueCount value is less or equal than 3.</remarks>
        /// <param name="queueCount">The number of queue count. Use system default value if it is 0.</param>
        /// <param name="width">A Width of queue.</param>
        /// <param name="height">A Height of queue.</param>
        /// <param name="colorFormat">A color format of queue.</param>
        /// <returns>A NativeImageQueue.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NativeImageQueue(uint queueCount, uint width, uint height, ColorFormat colorFormat) : this(Interop.NativeImageQueue.NewHandle(queueCount, width, height, (int)colorFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal NativeImageQueue(IntPtr cPtr, bool cMemoryOwn) : base(Interop.NativeImageQueue.Get(cPtr), cMemoryOwn)
        {
            handle = cPtr;
        }

        /// <summary>
        /// The number of queue.
        /// </summary>
        /// <remarks>Hidden API: Only for inhouse or developing usage. The behavior and interface can be changed anytime.</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetQueueCount()
        {
            uint ret = Interop.NativeImageQueue.GetQueueCount(this.SwigCPtr.Handle);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Generate Url from native image queue.
        /// </summary>
        /// <remarks>
        /// This API should not be called at worker thread.
        /// </remarks>
        /// <returns>The ImageUrl of NativeImageQueue.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageUrl GenerateUrl()
        {
            ImageUrl ret = new ImageUrl(Interop.NativeImageQueue.GenerateUrl(this.SwigCPtr.Handle), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NativeImageQueue.Delete(handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Checks if the buffer can be got from the queue.
        /// </summary>
        /// <returns>True if the buffer can be got from the queue.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanDequeueBuffer()
        {
            bool ret = Interop.NativeImageQueue.CanDequeueBuffer(this.SwigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dequeue buffer from the queue.
        /// </summary>
        /// <param name="width">A reference to the buffer's width.</param>
        /// <param name="height">A reference to the buffer's height.</param>
        /// <param name="stride">A reference to the buffer's stride.</param>
        /// <returns>A handle of buffer.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr DequeueBuffer(ref int width, ref int height, ref int stride)
        {
            IntPtr ret = Interop.NativeImageQueue.DequeueBuffer(this.SwigCPtr.Handle, ref width, ref height, ref stride);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enqueue buffer to the queue.
        /// </summary>
        /// <param name="buffer">A Handle of buffer to be enqueued.</param>
        /// <returns>True if success.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnqueueBuffer(IntPtr buffer)
        {
            bool ret = Interop.NativeImageQueue.EnqueueBuffer(this.SwigCPtr.Handle, buffer);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
