﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Ticket
{
    private static int tk = 0x140;

    #region Ticket Data
    private static byte[] dlcPatch = new byte[]
    {
        0x00, 0x01, 0x00, 0x14, 0x00, 0x00, 0x00, 0xAC, 0x00, 0x00, 0x00, 0x14, 0x00, 0x01, 0x00, 0x14, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x84, 0x00, 0x00, 0x00, 0x84, 0x00, 0x03,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00
    };
    private static byte[] ticketTemplate = new byte[]
    {
        0x00, 0x01, 0x00, 0x04, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1,
        0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E,
        0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15,
        0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A,
        0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5,
        0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB,
        0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1,
        0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED,
        0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1,
        0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E,
        0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15,
        0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A,
        0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5,
        0xED, 0x15, 0xAB, 0xE1, 0x1A, 0xD1, 0x5E, 0xA5, 0xED, 0x15, 0xAB, 0xE1, 0x1A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x52, 0x6F, 0x6F,
        0x74, 0x2D, 0x43, 0x41, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x33, 0x2D, 0x58, 0x53, 0x30, 0x30, 0x30, 0x30,
        0x30, 0x30, 0x30, 0x63, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA,
        0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED,
        0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0xFE,
        0xED, 0xFA, 0xCE, 0xFE, 0xED, 0xFA, 0xCE, 0x01, 0x00, 0x00, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC,
        0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0xCC, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x14, 0x00, 0x00, 0x00, 0xAC,
        0x00, 0x00, 0x00, 0x14, 0x00, 0x01, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00,
        0x01, 0x00, 0x00, 0x00, 0x84, 0x00, 0x00, 0x00, 0x84, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
    };

    #endregion

    private static byte[] StringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                            .ToArray();
    }
    public static void patchDemo(ref byte[] ticket)
    {
        for(int i = 0; i < 64; i++)
        {
            ticket[tk + 164 + i] = 0;
        }
    }
    public static void patchDLC(ref byte[] ticket)
    {
        Buffer.BlockCopy(dlcPatch, 0, ticket, tk + 0x164, dlcPatch.Length);
    }
    public static byte[] makeTicket(string titleID, string titleKey, int titleVersion, bool patchDemo = false, bool patchDLC = false)
    {
        byte[] ticket = (byte[])ticketTemplate.Clone();
        byte[] version = new byte[] { (byte)(titleVersion >> 8), (byte)titleVersion };
        byte[] id = StringToByteArray(titleID);
        byte[] key = StringToByteArray(titleKey);

        Buffer.BlockCopy(version, 0, ticket, tk + 0xA6, 2);
        Buffer.BlockCopy(id, 0, ticket, tk + 0x9C, id.Length);
        Buffer.BlockCopy(key, 0, ticket, tk + 0x7F, key.Length);

        if (patchDemo)
            Ticket.patchDemo(ref ticket);

        if (patchDLC)
            Ticket.patchDLC(ref ticket);

        return ticket;
    }
}
