<template>
    <Section title="Sobre Mim">
        <div class="about-content">
            <p>Olá! Sou desenvolvedor com X anos de experiência...</p>
            <ul>
                <li>📍 Localização: Sua Cidade</li>
                <li>🎓 Formação: Sua Formação</li>
            </ul>
        </div>
    </Section>
</template>

<script setup>import Section from '@/components/Section.vue';</script>

<style scoped>
    .about-content {
        line-height: 1.6;
    }

        .about-content ul {
            margin-top: 1rem;
            padding-left: 1.5rem;
        }
</style>