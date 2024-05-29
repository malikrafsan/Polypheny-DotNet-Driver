// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: org/polypheny/prism/error.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Polypheny.Prism {

  /// <summary>Holder for reflection information generated from org/polypheny/prism/error.proto</summary>
  public static partial class ErrorReflection {

    #region Descriptor
    /// <summary>File descriptor for org/polypheny/prism/error.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ErrorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch9vcmcvcG9seXBoZW55L3ByaXNtL2Vycm9yLnByb3RvEhNvcmcucG9seXBo",
            "ZW55LnByaXNtInYKDEVycm9yRGV0YWlscxIXCgplcnJvcl9jb2RlGAEgASgF",
            "SACIAQESEgoFc3RhdGUYAiABKAlIAYgBARIUCgdtZXNzYWdlGAMgASgJSAKI",
            "AQFCDQoLX2Vycm9yX2NvZGVCCAoGX3N0YXRlQgoKCF9tZXNzYWdlQksKE29y",
            "Zy5wb2x5cGhlbnkucHJpc21CBUVycm9yUAFaGW9yZy9wb2x5cGhlbnkvcHJp",
            "c207cHJpc22qAg9Qb2x5cGhlbnkuUHJpc21iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Polypheny.Prism.ErrorDetails), global::Polypheny.Prism.ErrorDetails.Parser, new[]{ "ErrorCode", "State", "Message" }, new[]{ "ErrorCode", "State", "Message" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///
  ///The ErrorDetails message conveys specific information about an error encountered during the processing of a request.
  ///This detailed feedback aids clients in understanding the nature and cause of an issue.
  /// </summary>
  public sealed partial class ErrorDetails : pb::IMessage<ErrorDetails>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ErrorDetails> _parser = new pb::MessageParser<ErrorDetails>(() => new ErrorDetails());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ErrorDetails> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Polypheny.Prism.ErrorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ErrorDetails() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ErrorDetails(ErrorDetails other) : this() {
      _hasBits0 = other._hasBits0;
      errorCode_ = other.errorCode_;
      state_ = other.state_;
      message_ = other.message_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ErrorDetails Clone() {
      return new ErrorDetails(this);
    }

    /// <summary>Field number for the "error_code" field.</summary>
    public const int ErrorCodeFieldNumber = 1;
    private int errorCode_;
    /// <summary>
    ///  A numeric code representing the specific error encountered. This code can be used programmatically to handle specific error cases.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ErrorCode {
      get { if ((_hasBits0 & 1) != 0) { return errorCode_; } else { return 0; } }
      set {
        _hasBits0 |= 1;
        errorCode_ = value;
      }
    }
    /// <summary>Gets whether the "error_code" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasErrorCode {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "error_code" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearErrorCode() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 2;
    private string state_;
    /// <summary>
    /// An optional state description in the form of an identifier that provides further context about the error.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string State {
      get { return state_ ?? ""; }
      set {
        state_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "state" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasState {
      get { return state_ != null; }
    }
    /// <summary>Clears the value of the "state" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearState() {
      state_ = null;
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 3;
    private string message_;
    /// <summary>
    /// A human-readable message describing the error in detail. This message offers clients a clear understanding of the issue.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_ ?? ""; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "message" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasMessage {
      get { return message_ != null; }
    }
    /// <summary>Clears the value of the "message" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearMessage() {
      message_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ErrorDetails);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ErrorDetails other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ErrorCode != other.ErrorCode) return false;
      if (State != other.State) return false;
      if (Message != other.Message) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (HasErrorCode) hash ^= ErrorCode.GetHashCode();
      if (HasState) hash ^= State.GetHashCode();
      if (HasMessage) hash ^= Message.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (HasErrorCode) {
        output.WriteRawTag(8);
        output.WriteInt32(ErrorCode);
      }
      if (HasState) {
        output.WriteRawTag(18);
        output.WriteString(State);
      }
      if (HasMessage) {
        output.WriteRawTag(26);
        output.WriteString(Message);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasErrorCode) {
        output.WriteRawTag(8);
        output.WriteInt32(ErrorCode);
      }
      if (HasState) {
        output.WriteRawTag(18);
        output.WriteString(State);
      }
      if (HasMessage) {
        output.WriteRawTag(26);
        output.WriteString(Message);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (HasErrorCode) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ErrorCode);
      }
      if (HasState) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(State);
      }
      if (HasMessage) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ErrorDetails other) {
      if (other == null) {
        return;
      }
      if (other.HasErrorCode) {
        ErrorCode = other.ErrorCode;
      }
      if (other.HasState) {
        State = other.State;
      }
      if (other.HasMessage) {
        Message = other.Message;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ErrorCode = input.ReadInt32();
            break;
          }
          case 18: {
            State = input.ReadString();
            break;
          }
          case 26: {
            Message = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            ErrorCode = input.ReadInt32();
            break;
          }
          case 18: {
            State = input.ReadString();
            break;
          }
          case 26: {
            Message = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code