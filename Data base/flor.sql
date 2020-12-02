-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-11-2020 a las 04:09:38
-- Versión del servidor: 10.4.16-MariaDB
-- Versión de PHP: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `flor`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `AccesoUsuario` (`_email` VARCHAR(255), `_clave` VARCHAR(255))  SELECT * FROM usuarios where email = _email AND clave = _clave$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `registrarusuario` (`_usuario` VARCHAR(255), `_pass` VARCHAR(255), `_email` VARCHAR(255), `_direccion_btc` VARCHAR(255), `_codigo_verificacion` INT)  INSERT INTO usuarios(usuario,clave,email,direccion_btc,codigo_verificacion) VALUES (_usuario,_pass,_email,_direccion_btc,_codigo_verificacion)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `verificarcodigo` (`_usuario` VARCHAR(255), `_codigo` INT)  SELECT * FROM usuarios where usuario = _usuario AND codigo_verificacion = _codigo$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL,
  `usuario` varchar(95) DEFAULT NULL,
  `clave` varchar(135) DEFAULT NULL,
  `email` varchar(135) DEFAULT NULL,
  `direccion_btc` varchar(135) DEFAULT NULL,
  `codigo_verificacion` int(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `usuario`, `clave`, `email`, `direccion_btc`, `codigo_verificacion`) VALUES
(40, 'Josue Perez', 'ds46dgf4df4g6d4f65g1fdg', 'josueceeu@gmail.com', 'dsf4gdfg6d4f6g56fd5g74fdgd', 418320),
(41, 'Pedro', 'dsfds54df4g1df4g4fdg', 'josueceeu@gmail.com', 'sd1f546ds4f6s4df651ds6f45ds', 556228),
(42, 'Luis', 'dsg56fg12fd2gdfg', 'josueceeu@gmail.com', '165ds4f6ds4f64ds65f456dsf', 533684),
(43, 'Carlos', 'sfsd564f6ds4f4ds6f4ds56f4ds', 'josueceeu@gmail.com', 'fds5fd4ds6f+ds5f+5ds+fsdf', 625135),
(44, 'sd8f4sd4fds74f74ds6f', '6ds4f6sd4f86ds7464fdsf', 'josueceeu@gmail.com', '4fds4f646dsf46ds4fsdf', 494527),
(45, 'Juan Luis', '+5649641486354156', 'josueceeu@gmail.com', 's6df486ds4f68ds46fds74fds', 518023),
(46, 'Martin', 'sd4f456ds4f564dsfdsf', 'josueceeu@gmail.com', '6sadf7498s74df84sdf78ds4fdsf', 629624),
(47, 'Luis', 'sdf46sd4f67ds4fds', 'josueceeu@gmail.com', 'sdf48ds74fds7f97dsf9ds', 409227),
(48, 'Luis', 'sdf46sd4f67ds4fds', 'josueceeu@gmail.com', 'sdf48ds74fds7f97dsf9ds', 355430),
(49, 'Juan Manuel', 'sdf+ds5f+5dsf+5dsf', 'josueceeu@gmail.com', 'dsf46ds74f6ds74f64ds6fsdf', 616794),
(50, 'Manuel', 'fddsfdsfdsfdsf', 'josueceeu@gmail.com', 'as4d6as64fda4s6f4564ff', 547126),
(51, 'Pedro Batista', '86dsf746ds4f6ds6f4dsf', 'josueceeu@gmail.com', '46sdf486ds4f6ds4fds6fdsf', 543756);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
