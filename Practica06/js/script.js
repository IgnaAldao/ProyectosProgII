function showSection(sectionId) {
    const sections = document.querySelectorAll('.main-content');
    sections.forEach(section => {
        section.classList.remove('active');
    });
    document.getElementById(sectionId).classList.add('active');
    if (sectionId === 'dashboard') {
        loadTurnosPorCliente();
    } else if (sectionId === 'consultar') {
        loadTurnos();
    }
}

async function loadServicios() {
    try {
        const response = await fetch('https://localhost:7190/api/Turnos');
        const servicios = await response.json();
        return servicios;
    } catch (error) {
        console.error("Error al obtener los servicios: ", error);
    }
}

async function loadTurnosPorCliente() {
    const servicios = await loadServicios();
    const turnosPorCliente = {};
    
    servicios.forEach(servicio => {
        if (!turnosPorCliente[servicio.cliente]) {
            turnosPorCliente[servicio.cliente] = 0;
        }
        turnosPorCliente[servicio.cliente]++;
    });

    const tbody = document.getElementById('totalTurnos');
    tbody.innerHTML = '';
    for (const cliente in turnosPorCliente) {
        tbody.innerHTML += `
            <tr>
                <td>${cliente}</td>
                <td>${turnosPorCliente[cliente]}</td>
            </tr>
        `;
    }
}

async function loadTurnos() {
    const servicios = await loadServicios();
    const tbody = document.getElementById('turnosTable');
    tbody.innerHTML = '';
    
    servicios.forEach(servicio => {
        tbody.innerHTML += `
            <tr>
                <td>${servicio.id}</td>
                <td>${servicio.fecha}</td>
                <td>${servicio.hora}</td>
                <td>${servicio.cliente}</td>
            </tr>
        `;
    });
}

document.getElementById('turnoForm').addEventListener('submit', async function(event) {
    event.preventDefault();

    const fecha = document.getElementById('fecha').value;
    const hora = document.getElementById('hora').value;
    const cliente = document.getElementById('cliente').value;

    if (fecha && hora && cliente) {
        try {
            const response = await fetch('https://localhost:7190/api/Turnos', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    fecha: fecha,
                    hora: hora,
                    cliente: cliente
                })
            });

            if (response.ok) {
                alert('Turno registrado con éxito');
                this.reset(); 
            } else {
                const errorData = await response.json();
                console.error('Error al registrar el turno:', errorData);
                alert('Error al registrar el turno');
            }
        } catch (error) {
            console.error('Error en la solicitud:', error);
            alert('Error al registrar el turno');
        }
    } else {
        alert('Por favor, complete todos los campos');
    }
});


showSection('dashboard');
