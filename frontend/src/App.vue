<template>
    <div class="app-container">
        <Sidebar @change-section="activeSection = $event" />

        <main class="content">
            <component :is="currentSectionComponent" />
        </main>
    </div>
</template>

<script setup>
    import { ref, computed } from 'vue';
    import Sidebar from './components/Sidebar.vue';
    import About from './views/About.vue';
    import Projects from './views/Projects.vue';
    import Skills from './views/Skills.vue';
    import Contact from './views/Contact.vue';

    const sections = {
        about: About,
        projects: Projects,
        skills: Skills,
        contact: Contact
    };

    const activeSection = ref('about');
    const currentSectionComponent = computed(() => sections[activeSection.value]);
</script>

<style scoped>
    .app-container {
        display: flex;
        min-height: 100vh;
    }

    .content {
        flex: 1;
        padding: 2rem;
        margin-left: 250px; /* Largura da sidebar */
        background-color: #f8f9fa;
    }
</style>