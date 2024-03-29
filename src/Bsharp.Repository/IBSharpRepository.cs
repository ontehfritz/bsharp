﻿namespace Bsharp.Repository
{
	using System.Collections.Generic;
    using Bsharp.Domain;

    public interface IBSharpRepository
    {
        void DeleteSong(string id);
        void CreateSong(Song song);
        Song Song(string id);
        Song Song(string name, string artistName, string albumName);
        IEnumerable<Song> Songs();

        void CreateArena(Arena arena);
        void UpdateArena(Arena arena);
        Arena Arena(string title);
        IEnumerable<Arena> Arenas();
        void Vote(Vote vote);

        void SubmitForNextBattle(Song song);

        void CreateUser(User user);
        void DeleteUser(string email);
        void UpdateUser(User user);
        User User(string email);
        IEnumerable<User> Users();
    }
}
