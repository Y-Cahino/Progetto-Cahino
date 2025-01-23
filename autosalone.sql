CREATE DATABASE IF NOT EXISTS autosaloni;
USE autosaloni;

-- Struttura della tabella `anni`
--

CREATE TABLE `anni` (
  `anno` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `autosalone`
--

CREATE TABLE `autosalone` (
  `bunghID` int(11) NOT NULL,
  `modello_id` int(11) NOT NULL,
  `anno_produzione` int(4) NOT NULL,
  `prezzo` int(11) NOT NULL,
  `marca_id` int(11) NOT NULL,
  `n_u` tinyint(1) NOT NULL,
  `test_drive` tinyint(1) NOT NULL,
  `promo` int(3) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `marche`
--

CREATE TABLE `marche` (
  `id` int(11) NOT NULL,
  `marca_n` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `marche`
--

INSERT INTO `marche` (`id`, `marca_n`) VALUES
(2, 'Toyota'),
(3, 'Peugeot'),
(4, 'Honda');

-- --------------------------------------------------------

--
-- Struttura della tabella `modelli`
--

CREATE TABLE `modelli` (
  `id` int(11) NOT NULL,
  `marca_id` int(11) NOT NULL,
  `modello_n` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `anni`
--
ALTER TABLE `anni`
  ADD PRIMARY KEY (`anno`);

--
-- Indici per le tabelle `autosalone`
--
ALTER TABLE `autosalone`
  ADD PRIMARY KEY (`bunghID`),
  ADD KEY `Marchs` (`marca_id`),
  ADD KEY `Anno_PR` (`anno_produzione`),
  ADD KEY `Models` (`modello_id`);

--
-- Indici per le tabelle `marche`
--
ALTER TABLE `marche`
  ADD PRIMARY KEY (`id`);

--
-- Indici per le tabelle `modelli`
--
ALTER TABLE `modelli`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Mod-Mr` (`marca_id`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `autosalone`
--
ALTER TABLE `autosalone`
  MODIFY `bunghID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `marche`
--
ALTER TABLE `marche`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT per la tabella `modelli`
--
ALTER TABLE `modelli`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `autosalone`
--
ALTER TABLE `autosalone`
  ADD CONSTRAINT `Anno_PR` FOREIGN KEY (`anno_produzione`) REFERENCES `anni` (`anno`),
  ADD CONSTRAINT `Marchs` FOREIGN KEY (`marca_id`) REFERENCES `marche` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `Models` FOREIGN KEY (`modello_id`) REFERENCES `modelli` (`id`);

--
-- Limiti per la tabella `modelli`
--
ALTER TABLE `modelli`
  ADD CONSTRAINT `Mod-Mr` FOREIGN KEY (`marca_id`) REFERENCES `marche` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
