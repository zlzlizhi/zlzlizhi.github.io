---
layout:     post
title:      "RaycastTarget"
subtitle:   "unity 3d"
date:       2019-10-23 16：33
author:     "ZLZ"
header-style:   "U3D"
header-img: "20190827142120667.png"
tags:
    - U3D
   
---

                                         
看过UGUI源码的朋友一定都知道，UI事件会在EventSystem在Update的Process触发。UGUI会遍历屏幕中所有RaycastTarget是true的UI，接着就会发射线，并且排序找到玩家最先触发的那个UI，在抛出事件给逻辑层去响应。

团队多人在开发游戏界面，很多时候都是复制黏贴，比如上一个图片是需要响应RaycastTarget，然后ctrl+d以后复制出来的也就带了这个属性，很可能新复制出来的图片是不需要响应的，开发人员又没有取消勾选掉，这就出问题了。

所以RaycastTarget如果被勾选的过多的话， 效率必然会低。。这个问题其实困扰了我很久，我终于想了一个还算好的方法解决它。

把下面代码挂在游戏中的任意GameObject上，原理其实很简单就是绘制辅助线，当UI中RaycastTarget发生变化，SceneView中的蓝色辅助线也会刷新，还是挺方便的。

```
#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DebugUILine : MonoBehaviour {
    static Vector3[] fourCorners = new Vector3[4];
    void OnDrawGizmos()
    {
        foreach (MaskableGraphic g in GameObject.FindObjectsOfType<MaskableGraphic>())
        {
            if (g.raycastTarget)
            {
                RectTransform rectTransform = g.transform as RectTransform;
                rectTransform.GetWorldCorners(fourCorners);
                Gizmos.color = Color.blue;
                for (int i = 0; i < 4; i++)
                    Gizmos.DrawLine(fourCorners[i], fourCorners[(i + 1) % 4]);
  
            }
        }
    }
}
#endif
```
如图
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190827142120667.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MTc5ODA3MQ==,size_16,color_FFFFFF,t_70)
Canvas的参数
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190827142217146.jpg?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MTc5ODA3MQ==,size_16,color_FFFFFF,t_70)
UICamera相机的参数
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190827142248143.jpg?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MTc5ODA3MQ==,size_16,color_FFFFFF,t_70)
这个脚本无论是运行模式，还是编辑模式都可以看到蓝色的辅助线，的理论上90%的文字或者 非按钮的图片 都是不需要RaycastTarget的。
<p><br></p>
<p>1、新建一个场景、将所要浏览的全景图导入项目中，设置属性如下：</p>
<p><br></p>
<p><img src="https://img-blog.csdn.net/20171026102359690?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvRkZfMTIyMQ==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/Center" alt=""></p>
<p><br></p>
<p>2、新建Material</p>
<p><img src="https://img-blog.csdn.net/20171026102606074?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvRkZfMTIyMQ==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/Center" alt=""><br></p>
<p><br></p>
<p>3、Window --&gt;&nbsp; Lighting --&gt; Settings 将刚刚创建的Material给天空球<img src="https://img-blog.csdn.net/20171026102812711?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvRkZfMTIyMQ==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/Center" alt=""></p>
                                    </div>


