﻿using Domain.Interfaces;
using Domain.Mapper;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VrijwilligersWerkBeheer : IVrijwilligersWerkBeheer
    {
      
            private VrijwilligersWerkRepository werkRepository = new VrijwilligersWerkRepository();
            private List<VrijwilligersWerk> werkLijst = new List<VrijwilligersWerk>();

            public VrijwilligersWerkBeheer()
            {
                
                var werkDTOs = werkRepository.HaalAlleWerkOp();
                foreach (var dto in werkDTOs)
                {
                    werkLijst.Add(WerkMapper.MapToVrijwilligerswerk(dto));
                }
            }

            // Methode om een nieuw werk toe te voegen
            public void VoegWerkToe(VrijwilligersWerkDTO werkDto)
            {
                var nieuwWerk = WerkMapper.MapToVrijwilligerswerk(werkDto);
                werkLijst.Add(nieuwWerk);

                
                var werkDTO = WerkMapper.MapToDTO(nieuwWerk);
                werkRepository.MaakNieuweWerkAan(werkDTO);

                Console.WriteLine("Nieuw vrijwilligerswerk succesvol toegevoegd.");
            }

            // Methode om alle werken te bekijken
            public List<string> BekijkAlleWerk()
            {
                var werkTitels = new List<string>();
                foreach (var werk in werkLijst)
                {
                    werkTitels.Add($"WerkID: {werk.WerkId}, Titel: {werk.Titel}");
                }
                return werkTitels;
            }

            // Methode om een werk te verwijderen
            public void VerwijderWerk(int werkId)
            {
                for (int i = 0; i < werkLijst.Count; i++)
                {
                    if (werkLijst[i].WerkId == werkId)
                    {
                        werkRepository.VerwijderWerk(werkId);  
                        werkLijst.RemoveAt(i);  
                        Console.WriteLine("Vrijwilligerswerk succesvol verwijderd.");
                        return;
                    }
                }
                Console.WriteLine("Werk niet gevonden.");
            }
        }

    }
