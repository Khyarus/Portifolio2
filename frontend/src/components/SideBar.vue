<template>
    <aside class="sidebar">
        <div class="profile">
            <img src="@/assets/images/profile.jpg" alt="Foto de Perfil">
            <h2>Seu Nome</h2>
            <p>Desenvolvedor Full-Stack</p>
        </div>

        <nav>
            <ul>
                <li v-for="(item, key) in menuItems"
                    :key="key"
                    :class="{ active: activeItem === key }"
                    @click="selectItem(key)">
                    {{ item.label }}
                </li>
            </ul>
        </nav>
    </aside>
</template>

<script setup>import { ref } from 'vue';

const emit = defineEmits(['change-section']);

const menuItems = {
  about: { label: 'Sobre Mim', icon: '👤' },
  projects: { label: 'Projetos', icon: '💻' },
  skills: { label: 'Habilidades', icon: '⚡' },
  contact: { label: 'Contato', icon: '✉️' }
};

const activeItem = ref('about');

const selectItem = (itemKey) => {
  activeItem.value = itemKey;
  emit('change-section', itemKey);
};</script>

<style scoped>
    .sidebar {
        width: 250px;
        height: 100vh;
        position: fixed;
        background: #2c3e50;
        color: white;
        padding: 1.5rem;
    }

    .profile img {
        width: 100px;
        height: 100px;
        border-radius: 50%;
        margin-bottom: 1rem;
    }

    nav ul {
        list-style: none;
        padding: 0;
    }

    nav li {
        padding: 0.75rem 1rem;
        margin: 0.5rem 0;
        cursor: pointer;
        border-radius: 4px;
        transition: background 0.3s;
    }

        nav li:hover {
            background: #34495e;
        }

        nav li.active {
            background: #3498db;
        }
</style>