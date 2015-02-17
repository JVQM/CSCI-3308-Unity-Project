CREATE TABLE IF NOT EXISTS `worker` (
`Id` int(1) NOT NULL auto_increment,
`Name` varchar(40) NOT NULL,
PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ; 
INSERT INTO `worker` (`Id`, `Name`) VALUES
(1, 'Jonathan Mai'),
(2, 'Eric Tran'),
(3, 'Justin Tang'),
(4, 'Michael Chung');

CREATE TABLE IF NOT EXISTS `Job` (
`pId` int(1) NOT NULL auto_increment,
`Position` varchar(40) NOT NULL,
`Description` varchar(75) NOT NULL,
PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ; 
INSERT INTO `Job` (`Id`, `Name`, `Description`) VALUES
(1, 'Jonathan Mai', 'Sprite Artwork,animation,camera use, gameplay'),
(2, 'Eric Tran', 'Background art, obstacles & level design'),
(3, 'Justin Tang','Menu functionality,screens,settings,score'),
(4, 'Michael Chung','Variety of Enemies(Sprite,animation,ai)');

CREATE TABLE IF NOT EXISTS `General` (
`Id` int(1) NOT NULL auto_increment,
`GeneralWork` varchar(40) NOT NULL,
PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ; 
INSERT INTO `General` (`Id`, `GeneralWork`) VALUES
(1, 'Health&Damage Scripts'),
(4, 'Health&Damage Scripts'),
(1, 'Lives&Difficulty'),
(2, 'Lives&Difficulty'),
(1, 'Game Camera Speed&Settings'),
(2, 'Game Camera Speed&Settings'),
(3, 'Game Camera Speed&Settings');
