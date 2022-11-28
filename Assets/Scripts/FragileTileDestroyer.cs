using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// References for detecting individual tile collision:
// https://stackoverflow.com/questions/64976889/detect-which-tilemap-cells-have-collided-with-a-collider2d-in-unity
// https://answers.unity.com/questions/1572343/how-to-detect-on-which-exact-tile-a-collision-happ.html

public class FragileTileDestroyer : MonoBehaviour
{
    public float destroyDelay = 0.25f;
    public Color impendingDestroyTint = new Color(1, 1, 1, 0.5f);

    private readonly float projectionScale = 0.1f;
    private GridLayout grid;
    private Tilemap tilemap;
    private HashSet<Vector3Int> seen = new HashSet<Vector3Int>();

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponentInParent<GridLayout>();
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        bool shouldBreak = collision.collider.CompareTag("Player") 
                            || collision.collider.CompareTag("Clone") 
                            || collision.collider.CompareTag("SecretItem");
        if (!shouldBreak)
        {
            // Only break the fragile tiles if player or clone collides
            return;
        }

        foreach (var contact in collision.contacts)
        {
            // The collision point lies at the boundary of the player and tile,
            // so using this point directly is error-prone. Instead we shift the collision
            // point along the collision normal, to "push" it into the touching tile.
            Vector2 projectedPoint = contact.point + (projectionScale * contact.normal);

            var cell = grid.WorldToCell(projectedPoint);
            var tile = tilemap.GetTile(cell);
            if (tile != null && tile.name == "FragileTile")
            {
                // Destroy a tile only once!
                if (seen.Contains(cell))
                {
                    continue;
                }
                seen.Add(cell);

                tilemap.SetTileFlags(cell, TileFlags.None);
                tilemap.SetColor(cell, impendingDestroyTint);
                if (!collision.collider.CompareTag("SecretItem"))
                {
                    SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.TileBreak);
                }
                StartCoroutine(BreakTile(cell));
            }
        }
    }

    private IEnumerator BreakTile(Vector3Int tilePosition)
    {
        yield return new WaitForSeconds(destroyDelay);
        tilemap.SetTile(tilePosition, null);
    }
}
