namespace PolyphenyDotNetDriver.Tests;

public class PolyphenyDataReaderTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void PolyphenyDataReader_WithNullData_ReturnsEmpty()
    {
        var reader = new PolyphenyDataReader(null);
        
        Assert.Multiple(() =>
        {
            Assert.That(reader.FieldCount, Is.EqualTo(0));
            Assert.That(reader.HasRows, Is.False);
            Assert.That(reader.IsClosed, Is.False);
        });
    }
    
    [Test]
    public void PolyphenyDataReader_WithNonNullData_ReturnsFilled()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.Multiple(() =>
        {
            Assert.That(reader.FieldCount, Is.EqualTo(1));
            Assert.That(reader.HasRows, Is.True);
            Assert.That(reader.IsClosed, Is.False);
        });
    }
    
    [Test]
    public void PolyphenyDataReader_Read_WithEmptyData_ReturnsFalse()
    {
        var data = new PolyphenyResultSets(["test"], Array.Empty<object[]>());
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.Read(), Is.False);
    }
    
    [Test]
    public void PolyphenyDataReader_Read_WithNonEmptyData_ReturnsTrue()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" }, new object[] { "test2"} });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.Read(), Is.True);
    }
    
    [Test]
    public void PolyphenyDataReader_Read_WithNonEmptyData_ReturnsFalseAfterLast()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" }, new object[] { "test2"} });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        reader.Read();
        
        Assert.That(reader.Read(), Is.False);
    }
    
    [Test]
    public void PolyphenyDataReader_GetValue_WithNonEmptyData_ReturnsCorrectValue()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetValue(0), Is.EqualTo("test"));
    }
    
    [Test]
    public void PolyphenyDataReader_GetValue_WithNonEmptyData_ReturnsCorrectType()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetFieldType(0), Is.EqualTo(typeof(string)));
    }
    
    [Test]
    public void PolyphenyDataReader_GetValue_WithNonEmptyData_ReturnsCorrectOrdinal()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetOrdinal("test"), Is.EqualTo(0));
    }
    
    [Test]
    public void PolyphenyDataReader_GetValue_WithNonEmptyData_ReturnsCorrectName()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetName(0), Is.EqualTo("test"));
    }
    
    [Test]
    public void PolyphenyDataReader_Close_WithNonEmptyData_ReturnsClosed()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        reader.Close();
        
        Assert.That(reader.IsClosed, Is.True);
    }
    
    [Test]
    public void PolyphenyDataReader_GetEnumerator_WithNonEmptyData_ReturnsEnumerator()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        var enumerator = reader.GetEnumerator();
        using var unknown = enumerator as IDisposable;

        Assert.That(enumerator, Is.Not.Null);
        
        // iterate through the enumerator
        while (enumerator.MoveNext())
        {
            Assert.That(enumerator.Current, Is.Not.Null);
        }
    }
    
    [Test]
    public void PolyphenyDataReader_Depth_WithNonEmptyData_ReturnsZero()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.Depth, Is.EqualTo(0));
    }
    
    [Test]
    public void PolyphenyDataReader_RecordsAffected_WithNonEmptyData_ReturnsZero()
    {
        var data = new PolyphenyResultSets(["test"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.RecordsAffected, Is.EqualTo(0));
    }
    
    [Test]
    public void PolyphenyDataReader_Item_WithNonEmptyData_ReturnsCorrectValue()
    {
        var data = new PolyphenyResultSets(["col1"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader[0], Is.EqualTo("test"));
    }
    
    [Test]
    public void PolyphenyDataReader_Item_WithNonEmptyData_ReturnsCorrectValueByName()
    {
        var data = new PolyphenyResultSets(["col1"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader["col1"], Is.EqualTo("test"));
    }
    
    [Test]
    public void PolyphenyDataReader_IsDBNull_WithNonEmptyData_ReturnsFalse()
    {
        var data = new PolyphenyResultSets(["col1"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.IsDBNull(0), Is.False);
    }

    [Test]
    public void PolyphenyDataReader_IsDBNull_WithNullResultSets_ThrowException()
    {
        var reader = new PolyphenyDataReader(null);
        
        Assert.Throws<Exception>(() =>
        {
            var isDbNull = reader.IsDBNull(0);
        });
    }
    
    [Test]
    public void PolyphenyDataReader_GetOrdinal_WithNonEmptyData_ReturnsCorrectOrdinal()
    {
        var data = new PolyphenyResultSets(["col1"], new object[][] { new object[] { "test" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetOrdinal("col1"), Is.EqualTo(0));
    }
    
    [Test]
    public void PolyphenyDataReader_GetValues_WithNonEmptyData_ReturnsCorrectValues()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { "test1", "test2" } });
        
        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        var values = new object[2];
        reader.GetValues(values);
        
        Assert.Multiple(() =>
        {
            Assert.That(values[0], Is.EqualTo("test1"));
            Assert.That(values[1], Is.EqualTo("test2"));
        });
    }

    [Test]
    public void PolyphenyDataReader_GetString_WithValidOrdinal_ReturnString()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { "test1", "test2" } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetString(0), Is.EqualTo("test1"));
    }
    
    [Test]
    public void PolyphenyDataReader_GetOrdinal_WithNullResultSets_ThrowsException()
    {
        var reader = new PolyphenyDataReader(null);
        
        Assert.Throws<Exception>(() =>
        {
            var ordinal = reader.GetOrdinal("col3");
        });
    }
    
    [Test]
    // test GetName after IsClosed
    public void PolyphenyDataReader_GetName_WithClosedReader_ThrowsException()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { "test1", "test2" } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        reader.Close();
        
        Assert.Throws<Exception>(() =>
        {
            var name = reader.GetName(0);
        });
    }
    
    [Test]
    public void PolyphenyDataReader_GetName_WithOutOfRangeOrdinal_ThrowsException()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { "test1", "test2" } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var name = reader.GetName(2);
        });
    }
    
    // test GetInt64, GetInt32, GetInt16, GetInt8, GetDecimal, GetFloat, GetDouble, GetBoolean, GetDateTime, GetGuid, GetByte, GetBytes, GetChar, GetChars, GetStream, GetTextReader, GetXmlReader, GetTimeSpan, GetDateTimeOffset
    [Test]
    public void PolyphenyDataReader_GetInt64_WithValidOrdinal_ReturnInt64()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { 1L, 2L } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetInt64(0), Is.EqualTo(1L));
    }
    
    [Test]
    public void PolyphenyDataReader_GetInt32_WithValidOrdinal_ReturnInt32()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { 1, 2 } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetInt32(0), Is.EqualTo(1));
    }
    
    [Test]
    public void PolyphenyDataReader_GetInt16_WithValidOrdinal_ReturnInt16()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { (short)1, (short)2 } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetInt16(0), Is.EqualTo((short)1));
    }
    
    [Test]
    public void PolyphenyDataReader_GetGuid_WithValidOrdinal_ReturnGuid()
    {
        var guid = Guid.NewGuid();
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { guid, Guid.NewGuid() } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetGuid(0), Is.EqualTo(guid));
    }
    
    [Test]
    public void PolyphenyDataReader_GetByte_WithValidOrdinal_ReturnByte()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { (byte)1, (byte)2 } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetByte(0), Is.EqualTo((byte)1));
    }
    
    [Test]
    public void PolyphenyDataReader_GetFloat_WithValidOrdinal_ReturnFloat()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { 1.0f, 2.0f } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetFloat(0), Is.EqualTo(1.0f));
    }
    
    // test getdouble
    [Test]
    public void PolyphenyDataReader_GetDouble_WithValidOrdinal_ReturnDouble()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { 1.0, 2.0 } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetDouble(0), Is.EqualTo(1.0));
    }
    
    // test getdecimal
    [Test]
    public void PolyphenyDataReader_GetDecimal_WithValidOrdinal_ReturnDecimal()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { 1.0m, 2.0m } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetDecimal(0), Is.EqualTo(1.0m));
    }
    
    [Test]
    // get datetime
    public void PolyphenyDataReader_GetDateTime_WithValidOrdinal_ReturnDateTime()
    {
        var dateTime = DateTime.Now;
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { dateTime, DateTime.Now } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetDateTime(0), Is.EqualTo(dateTime));
    }
    
    // test getchars
    [Test]
    public void PolyphenyDataReader_GetChars_WithValidOrdinal_ReturnChars()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { "test", "test2" } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        var buffer = new char[4];
        reader.GetChars(0, 0, buffer, 0, 4);
        
        Assert.That(buffer, Is.EqualTo(new char[] { 't', 'e', 's', 't' }));
    }
    
    // test getchar
    [Test]
    public void PolyphenyDataReader_GetChar_WithValidOrdinal_ReturnChar()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { 't', 't' } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetChar(0), Is.EqualTo('t'));
    }
    
    [Test]
    public void PolyphenyDataReader_GetBytes_WithValidOrdinal_ReturnBytes()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { new byte[] { 1, 2, 3 }, new byte[] { 4, 5, 6 } } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        var buffer = new byte[3];
        reader.GetBytes(0, 0, buffer, 0, 3);
        
        Assert.That(buffer, Is.EqualTo(new byte[] { 1, 2, 3 }));
    }
    
    [Test]
    public void PolyphenyDataReader_GetBytes_WithNullBuffer_ThrowsException()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { new byte[] { 1, 2, 3 }, new byte[] { 4, 5, 6 } } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        var result = reader.GetBytes(0, 0, null, 0, 3);
        Assert.That(result, Is.EqualTo(3));
    }
    
    [Test]
    public void PolyphenyDataReader_GetBytes_WithIndexOutOfRange_ThrowsException()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { new byte[] { 1, 2, 3 }, new byte[] { 4, 5, 6 } } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            var buffer = new byte[3];
            reader.GetBytes(0, 4, buffer, 0, 3);
        });
    }
    
    [Test]
    public void PolyphenyDataReader_GetBoolean_WithValidOrdinal_ReturnBoolean()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { true, false } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.That(reader.GetBoolean(0), Is.True);
    }
    
    [Test]
    public void PolyphenyDataReader_GetSchemaTable_WithValidData_ReturnsSchemaTable()
    {
        string[] cols = ["col1", "col2"];
        var data = new PolyphenyResultSets(cols, new object[][] { new object[] { true, false } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;

        var columns = reader.Columns;
        
        Assert.That(columns, Is.EqualTo(cols));
    }
    
    [Test]
    public void PolyphenyDataReader_GetCast_WithValidOrdinal_ReturnsValue()
    {
        var data = new PolyphenyResultSets(["col1", "col2"], new object[][] { new object[] { true, false } });

        var reader = new PolyphenyDataReader(null);
        reader.ResultSets = data;
        
        Assert.Throws<Exception>(() =>
        {
            var value = reader.GetInt32(0);
        });
    }
}