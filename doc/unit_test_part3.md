# 單元測試
## Overview
- [Private,Internal方法的測試](#privateinternal方法的測試)
- [MsTest – Unit Test Event Hooks](#mstest-–-unit-test-event-hooks)
- [NSubstitute](#nsubstitute)
- [Moq](#moq)
- [AutoFixture](#autofixture)
- [ExpectedObjects](#expectedobjects)
## Private,Internal方法的測試
- 盡量不對private方法測試，透過public方法應該就可以測到private方法
- .Net framework有PrivateObject或PrivateType可以使用，.net core以後已捨棄
- 測試internal方法需要調整專案設定

在csproj加上以下或是調整assembly.cs檔案
```
<ItemGroup>
    <AssemblyAttribute Include="System.Runtime.CompilerServices.InternalsVisibleTo">
      <_Parameter1>TestProject</_Parameter1>
    </AssemblyAttribute>
</ItemGroup>
```

## MsTest – Unit Test Event Hooks
1. ClassInitializeAttribute 類別 <br>
該方法所包含的程式碼須**用於測試類別中的所有測試都完成執行之前**，以便配置此測試類別所使用的資源。
2. ClassCleanupAttribute 類別 <br>
該方法所包含的程式碼**用於測試類別中的所有測試都完成執行之後**，以便釋放此測試類別所佔用的資源。
3. TestInitializeAttribute 類別<br>
此方法要**在測試之前執行**，以便配置和設定測試類別中所有測試所需的資源
4. TestCleanupAttribute 類別<br>
該方法所包含的程式碼必須於**測試完成執行之後使用**，以便釋放此測試類別中所有測試所佔用的資源。*
![](/img/hook1.jpg)
![](/img/hook2.jpg)

### 執行測試結果
![](/img/hookres.jpg)

## NSubstitute
> 隔離框架，避免與外部資源直接相依

- 加入Nsubstisute[套件](https://www.nuget.org/packages/nsubstitute/)
- [doc](https://nsubstitute.github.io/help/getting-started/)
- Substitue.For< T >()產生 Interface的Stub物件
- 定義Stub物件的行為與回傳值Stub物件.方法(你要輸入參數).Returns(你想要回傳的值)
```C#
var profileRepository = Substitute.For<IProfileRepository>();
 profileRepository.GetPassword(account).Returns("000");
```


## Moq
> mocking library，跟NSubstitute可擇一使用
- [github](https://github.com/devlooped/moq)
- [nuget](https://www.nuget.org/packages/Moq)

範例
```C#
var profileRepository = new Mock<IProfileRepository>();
profileRepository.Setup(x=>x.GetPassword(account)).Return("000")
```

#### 參考
[瞭解Mock假物件(moq)](https://blog.miniasp.com/post/2010/09/16/ASPNET-MVC-Unit-Testing-Part-03-Using-Mock-moq)


## AutoFixture
- [github](https://github.com/AutoFixture/AutoFixture)
- 可以自動產生測試用的資料，不用自己new一個物件出來
- 針對要測試的欄位給值
- Create():建單個物件
- CreateMany(count):建立集合

實際使用範例
![](/img/autofixture.jpg)

## ExpectedObjects
- 前情提要:[物件的比較](https://github.com/shadow061103/UnitTest.Demo/blob/master/doc/unit_test_part2.md#物件的比較-areequalsaresame)<br>
- Assert.AreEqual底層是用Object.Equals去比較
所以同個class物件去比較，除了比較屬性值要相等，還會比較reference也要相等
- 如果沒有覆寫Equals與GetHashCode方法，用Assert.AreEquals比對就會失敗
- class的屬性一多，要覆寫就變得很麻煩，可以用ExpectedObjects直接省略這個步驟

![](/img/equalerror3.jpg)
![](/img/equalerror2.jpg)