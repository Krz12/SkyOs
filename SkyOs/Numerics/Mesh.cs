namespace SkyOs.Numerics
{
    public struct Mesh
    {
        public Mesh(Triangle<float>[] Triangles)
        {
            this.Triangles = Triangles;
        }

        public Triangle<float>[] Triangles;
    }
}