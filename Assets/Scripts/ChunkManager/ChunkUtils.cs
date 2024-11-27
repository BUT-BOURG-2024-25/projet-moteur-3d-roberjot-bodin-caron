using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChunkUtils
{

    public static int ConvertToChunkId(Vector2 chunkPos)
    {
        var (xPrime, yPrime) = TransformCoordinates((int)chunkPos.x, (int)chunkPos.y);
        return CantorPairing(xPrime, yPrime);
    }

    // Fonction pour obtenir les coordonnées à partir de l'ID de chunk
    public static Vector2 FromChunkId(int chunkId)
    {
        var (xPrime, yPrime) = ReverseCantorPairing(chunkId);

        bool isXNegate = xPrime % 2 == 1;
        bool isYNegate = yPrime % 2 == 1;

        int x = (isXNegate ? -(xPrime - 1) : xPrime) / 2;
        int y = (isYNegate ? -(yPrime - 1) : yPrime) / 2;

        return new Vector2(x, y);
    }

    // Fonction de décodage de Cantor Pairing (inverse)
    private static (int, int) ReverseCantorPairing(int value)
    {
        int w = (int)((Math.Sqrt(8 * value + 1) - 1) / 2);
        int t = (w * (w + 1)) / 2;
        int y = value - t;
        int x = w - y;

        return (x, y);
    }

    // Transformation des coordonnées pour les rendre positives et ajustées
    private static (int, int) TransformCoordinates(int x, int y)
    {
        int xPrime = 2 * Math.Abs(x) + (x < 0 ? 1 : 0);
        int yPrime = 2 * Math.Abs(y) + (y < 0 ? 1 : 0);
        return (xPrime, yPrime);
    }

    // Fonction de Cantor Pairing
    private static int CantorPairing(int x, int y)
    {
        int xy = x + y;
        return (xy * (xy + 1)) / 2 + y;
    }
}
