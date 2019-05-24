layout:     post
title:      List与ArrayList的区别
subtitle:  List与ArrayList的区别
date:       2019-05-24
author:     ZLZ
header-img: img/345.jpg
catalog: true
tags:
    - C#
---


## 前言

刚搭建完博客，先写一篇试试。但是从来没有仔细探究过List与ArrayList的关系,今天我根据平时的经验和在网上查了一些资料,简单的总结一下:


## 正文
###ArrayList
ArrayList是.Net Framework提供的用于数据存储和检索的专用类，它是命名空间System.Collections下的一部分。它的大小是按照其中存储的数据来动态扩充与收缩的。所以，我们在声明ArrayList对象时并不需要指定它的长度。ArrayList继承了IList接口，所以它可以很方便的进行数据的添加。
```

但它同样存在缺点,那就是类型不安全和性能损耗大(由于存在装箱,拆箱)，所以在C#2.0后又会出现List对象来补充它.
　　在上面的代码中,我们不仅插入了字符串"acrs"，而且又插入了数字123。这样在ArrayList中插入不同类型的数据是允许的。因为ArrayList会把所有插入其中的数据都当作为object类型来处理。这样，在我们使用ArrayList中的数据来处理问题的时候，很可能会报类型不匹配的错误，也就是说ArrayList不是类型安全的。既使我们保证在插入数据的时候都很小心，都有插入了同一类型的数据，但在使用的时候，我们也需要将它们转化为对应的原类型来处理。这就存在了装箱与拆箱的操作，会带来很大的性能损耗。



```

###List
List类是ArrayList类的泛型等效类。它的大部分用法都与ArrayList相似，因为List类也继承了IList接口。最关键的区别在于，在声明List集合时，我们同时需要为其声明List集合内数据的对象类型。

如果我们往List集合中插入string字符"hello world"，IDE就会报错，且不能通过编译。这样就避免了前面讲的类型安全问题与装箱拆箱的性能问题了。也就是如果使用List,那么集合内的数据类型有且只能是一种,不允许多种。
List不能被构造，但可以向上面那样为List创建一个引用，而ListArray就可以被构造
即:
ist list;     //正确   list=null; 
List list=new List();    //   是错误的用法
List<int> list = new List<int>();  //正确
List<int> list = new ArrayList<>();   //正确,需要注意的是;这句创建了一个ArrayList的对象后把赋值给了List。此时它是一个List对象了，所以会出现有些ArrayList有但是List没有的属性和方法，那么这个List对象就不能再用了
ListArray listArray = new ListArray();   //正确,这里创建的对象则保留了ArrayList的所有属性







