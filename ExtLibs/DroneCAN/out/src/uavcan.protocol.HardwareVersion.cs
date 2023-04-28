
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;

using int8_t = System.SByte;
using int16_t = System.Int16;
using int32_t = System.Int32;
using int64_t = System.Int64;

using float32 = System.Single;

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace DroneCAN
{
    public partial class DroneCAN {
        static void encode_uavcan_protocol_HardwareVersion(uavcan_protocol_HardwareVersion msg, dronecan_serializer_chunk_cb_ptr_t chunk_cb, object ctx, bool fdcan) {
            uint8_t[] buffer = new uint8_t[8];
            _encode_uavcan_protocol_HardwareVersion(buffer, msg, chunk_cb, ctx, !fdcan);
        }

        static uint32_t decode_uavcan_protocol_HardwareVersion(CanardRxTransfer transfer, uavcan_protocol_HardwareVersion msg, bool fdcan) {
            uint32_t bit_ofs = 0;
            _decode_uavcan_protocol_HardwareVersion(transfer, ref bit_ofs, msg, !fdcan);
            return (bit_ofs+7)/8;
        }

        static void _encode_uavcan_protocol_HardwareVersion(uint8_t[] buffer, uavcan_protocol_HardwareVersion msg, dronecan_serializer_chunk_cb_ptr_t chunk_cb, object ctx, bool tao) {
            memset(buffer,0,8);
            canardEncodeScalar(buffer, 0, 8, msg.major);
            chunk_cb(buffer, 8, ctx);
            memset(buffer,0,8);
            canardEncodeScalar(buffer, 0, 8, msg.minor);
            chunk_cb(buffer, 8, ctx);
            for (int i=0; i < 16; i++) {
                    memset(buffer,0,8);
                    canardEncodeScalar(buffer, 0, 8, msg.unique_id[i]);
                    chunk_cb(buffer, 8, ctx);
            }
            if (!tao) {
                memset(buffer,0,8);
                canardEncodeScalar(buffer, 0, 8, msg.certificate_of_authenticity_len);
                chunk_cb(buffer, 8, ctx);
            }
            for (int i=0; i < msg.certificate_of_authenticity_len; i++) {
                    memset(buffer,0,8);
                    canardEncodeScalar(buffer, 0, 8, msg.certificate_of_authenticity[i]);
                    chunk_cb(buffer, 8, ctx);
            }
        }

        static void _decode_uavcan_protocol_HardwareVersion(CanardRxTransfer transfer,ref uint32_t bit_ofs, uavcan_protocol_HardwareVersion msg, bool tao) {

            canardDecodeScalar(transfer, bit_ofs, 8, false, ref msg.major);
            bit_ofs += 8;

            canardDecodeScalar(transfer, bit_ofs, 8, false, ref msg.minor);
            bit_ofs += 8;

            for (int i=0; i < 16; i++) {
                canardDecodeScalar(transfer, bit_ofs, 8, false, ref msg.unique_id[i]);
                bit_ofs += 8;
            }

            if (!tao) {
                canardDecodeScalar(transfer, bit_ofs, 8, false, ref msg.certificate_of_authenticity_len);
                bit_ofs += 8;
            } else {
                msg.certificate_of_authenticity_len = (uint8_t)(((transfer.payload_len*8)-bit_ofs)/8);
            }

            msg.certificate_of_authenticity = new uint8_t[msg.certificate_of_authenticity_len];
            for (int i=0; i < msg.certificate_of_authenticity_len; i++) {
                canardDecodeScalar(transfer, bit_ofs, 8, false, ref msg.certificate_of_authenticity[i]);
                bit_ofs += 8;
            }

        }
    }
}