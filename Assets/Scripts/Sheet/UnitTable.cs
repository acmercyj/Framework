//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: proto/UnitTable.proto
namespace Sheet
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UnitTable")]
  public partial class UnitTable : global::ProtoBuf.IExtensible
  {
    public UnitTable() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int id
    {
      get { return _id; }
      set { _id = value; }
    }
    private string _model = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"model", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string model
    {
      get { return _model; }
      set { _model = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _behaviors = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(3, Name=@"behaviors", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> behaviors
    {
      get { return _behaviors; }
    }
  
    private float _moveSpeed = (float)0;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"moveSpeed", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue((float)0)]
    public float moveSpeed
    {
      get { return _moveSpeed; }
      set { _moveSpeed = value; }
    }
    private float _maxHP = (float)0;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"maxHP", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue((float)0)]
    public float maxHP
    {
      get { return _maxHP; }
      set { _maxHP = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UnitTable_ARRAY")]
  public partial class UnitTable_ARRAY : global::ProtoBuf.IExtensible
  {
    public UnitTable_ARRAY() {}
    
    private readonly global::System.Collections.Generic.List<Sheet.UnitTable> _items = new global::System.Collections.Generic.List<Sheet.UnitTable>();
    [global::ProtoBuf.ProtoMember(1, Name=@"items", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Sheet.UnitTable> items
    {
      get { return _items; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}