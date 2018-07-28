public interface IHydratable {
  bool IsHydrated { get; set; }

  void Hydrate();
}