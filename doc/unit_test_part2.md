# 單元測試
## Overview
- [單元測試的內容](#單元測試的內容)
- [測試相關標籤](#測試相關標籤)
- [群組依據](#群組依據)
- [Assert類別](#assert類別)
- [驗證exception](#驗證exception)
- [Fluent Assertions](#fluent-assertions)
- [物件的比較](#物件的比較-areequalsaresame)

## 單元測試的內容
- 受測對象 =>可使用target或sut(system under test)
- 預期結果 => expected
- 實際執行結果 => actual

![](/img/test_content2.jpg)
## 測試相關標籤
1. MsTest
- [TestClass()]
- [TestMethod()]
- [Owenr(“User_Name”)]
- [TestCategory(“Calculator”)]
- [TestProperty(“Calculator”, “Add”)]
- [Ignore]
2. Xunit
- [Fact]
- [Fact(Skip = "")]
- [Theory] : 代表執行相同程式碼但具有不同輸入引數的測試套件
- [InlineData] : 可以傳入不同的input
- [Trait]


## 群組依據
方便管理單元測試：
- 類別 – 依據類別區分群組
- 持續期間 – 依據執行時間區分群組
- 結果 – 依據執行結果區分群組
- 特性 – 依據 TestCategory 內容區分群組
- 專案 – 依據測試專案區分群組

### MSTest
設定測試屬性
![](/img/group.jpg)

測試分組
![](/img/group2.jpg)

### XUnit
使用Trait屬性

![](/img/trait1.jpg)

測試總管

![](/img/trait2.jpg)

## Assert類別
介紹常用的
- Assert.AreEqual(expected, actual);
- Assert.AreNotEqual(expected, actual);
- Assert.IsTrue(actual);
- Assert.IsFalse(actual);
- Assert.IsNull(actual);
- Assert.IsNotNull(actual);
- Assert.IsInstanceOfType(actual, typeof(expectedType));
- Assert.IsNotInstanceOfType(actual, typeof(wrongType));

[Assert class](https://learn.microsoft.com/zh-tw/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=visualstudiosdk-2022&redirectedfrom=MSDN)

### 驗證exception的方法
1. 不要使用try catch!

![](/img/test_exception.jpg)

2. 使用ExpectedException Attribute

![](/img/test_exception2.jpg)

3. 自訂驗證擴充方法
```c#
 public static class AssertExtensions
    {
        public static T ThrowException<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T ex)
            {
                //MSTest
                throw ex; 
                //Xunit
                //return ex; 
            }

            return null;
        }
    }
```
![](/img/test_exception3.jpg)

4. 非同步方法的驗證
![](/img/asyncerror.jpg)

### Fluent Assertions
> 用口語的方式對測試做Assert

[doc](https://fluentassertions.com/)
[nuget](https://www.nuget.org/packages/FluentAssertions)
![](/img/fluentassert.jpg)

只適用於XUnit測試專案

![](/img/fluentassert2.jpg)


### 物件的比較 AreEquals,AreSame

1. `Assert.AreEquals`或`Assert.Equal`:
確認兩個指定的物件相等。 如果這些物件都不相等，判斷提示就會失敗

2. `Assert.AreSame`或`Assert.NotSame`:確認兩個指定的物件變數參考相同的物件。 如果它們參考不同的物件，判斷提示就會失敗。

上述名稱會因為test framework的不同而有差異

#### CLR的相等性
- 值相等性:「數值型別」如果型別的值相等，則回傳 True
- 引用相等性:「參考型別」如果型別指向同一個對象，則回傳 True

#### 覆寫 Object 基礎類別的 Equals 與 GetHashCode 方法
- 覆寫 Equals 方法:告知 CLR 應該如何去比對兩個參考型別的物件
- 覆寫 GetHashCode 方法:如果有覆寫 Equals 方法時，也必須覆寫 GetHashCode 方法。
當物件實例化之後，CLR 會為物件產生一個固定的值，該值在物件的生存週期內不會改變。
![](/img/objecttest.jpg)